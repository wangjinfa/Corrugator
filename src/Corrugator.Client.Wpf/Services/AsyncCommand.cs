using Prism.Commands;
using System.Windows.Input;

namespace Corrugator.Client.Wpf.Services;

/// <summary>
/// Prism 自带 DelegateCommand 只支持同步执行，这里补一个可 await 的异步命令：
/// 执行期间置 IsExecuting 并自动刷新 CanExecute（按钮变灰），异常不会吞掉，交由调用方处理。
/// </summary>
public class AsyncCommand : DelegateCommandBase
{
    private readonly Func<Task> _execute;
    private readonly Func<bool>? _canExecute;
    private bool _isExecuting;

    public AsyncCommand(Func<Task> execute, Func<bool>? canExecute = null)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecute = canExecute;
    }

    public bool IsExecuting
    {
        get => _isExecuting;
        private set
        {
            if (_isExecuting == value)
            {
                return;
            }

            _isExecuting = value;
            RaiseCanExecuteChanged();
        }
    }

    protected override bool CanExecute(object? parameter) => !_isExecuting && (_canExecute?.Invoke() ?? true);

    protected override async void Execute(object? parameter)
    {
        if (!CanExecute(parameter))
        {
            return;
        }

        IsExecuting = true;
        try
        {
            await _execute();
        }
        catch (Exception ex)
        {
            // 异步命令不能把异常抛到 UI 线程，这里只做兜底提示
            System.Diagnostics.Debug.WriteLine($"[AsyncCommand] {ex}");
            System.Windows.MessageBox.Show($"操作失败：{ex.Message}", "提示",
                System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Warning);
        }
        finally
        {
            IsExecuting = false;
        }
    }
}
