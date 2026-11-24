using Corrugator.Application.Services;
using Corrugator.Shared.Api;
using Corrugator.Shared.Contracts.Dashboard;
using Corrugator.Shared.Contracts.Dictionary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Corrugator.Api.Controllers;

[ApiController]
[Route("api/dashboard")]
[Authorize]
public class DashboardController : ControllerBase
{
    private readonly IDashboardService _service;

    public DashboardController(IDashboardService service)
    {
        _service = service;
    }

    /// <summary>生管看板概览</summary>
    [HttpGet("overview")]
    public async Task<ApiResult<DashboardOverviewDto>> Overview()
        => ApiResult<DashboardOverviewDto>.Ok(await _service.GetOverviewAsync());
}

[ApiController]
[Route("api/dictionary")]
[Authorize]
public class DictionaryController : ControllerBase
{
    private readonly IDictionaryService _service;

    public DictionaryController(IDictionaryService service)
    {
        _service = service;
    }

    /// <summary>字典类型列表（W_DictTypes）</summary>
    [HttpGet("types")]
    public async Task<ApiResult<List<DictTypeDto>>> Types()
        => ApiResult<List<DictTypeDto>>.Ok(await _service.GetTypesAsync());

    /// <summary>指定类型的字典明细（W_DictDatas）</summary>
    [HttpGet("types/{typeId:int}/data")]
    public async Task<ApiResult<List<DictDataDto>>> Data(int typeId)
        => ApiResult<List<DictDataDto>>.Ok(await _service.GetDatasAsync(typeId));

    /// <summary>新增字典分类</summary>
    [HttpPost("types")]
    public async Task<ApiResult<DictTypeDto>> CreateType([FromBody] DictTypeSaveRequest request)
    {
        if (!IsAdmin)
        {
            return ApiResult<DictTypeDto>.Fail("仅管理员可维护数据字典", 403);
        }

        if (string.IsNullOrWhiteSpace(request.WPD_Name))
        {
            return ApiResult<DictTypeDto>.Fail("中文名不能为空");
        }

        var dto = await _service.CreateTypeAsync(request, User.Identity?.Name);
        return ApiResult<DictTypeDto>.Ok(dto, "已新增");
    }

    /// <summary>修改字典分类</summary>
    [HttpPut("types/{id:int}")]
    public async Task<ApiResult<DictTypeDto>> UpdateType(int id, [FromBody] DictTypeSaveRequest request)
    {
        if (!IsAdmin)
        {
            return ApiResult<DictTypeDto>.Fail("仅管理员可维护数据字典", 403);
        }

        if (string.IsNullOrWhiteSpace(request.WPD_Name))
        {
            return ApiResult<DictTypeDto>.Fail("中文名不能为空");
        }

        var dto = await _service.UpdateTypeAsync(id, request, User.Identity?.Name);
        return dto is null
            ? ApiResult<DictTypeDto>.Fail("记录不存在", 404)
            : ApiResult<DictTypeDto>.Ok(dto, "已保存");
    }

    /// <summary>删除字典分类（有子分类或明细时拒绝）</summary>
    [HttpDelete("types/{id:int}")]
    public async Task<ApiResult<ApiEmpty>> DeleteType(int id)
    {
        if (!IsAdmin)
        {
            return ApiResult<ApiEmpty>.Fail("仅管理员可维护数据字典", 403);
        }

        var error = await _service.DeleteTypeAsync(id);
        return error is null
            ? ApiResult<ApiEmpty>.Ok(new ApiEmpty(), "已删除")
            : ApiResult<ApiEmpty>.Fail(error);
    }

    /// <summary>新增字典明细</summary>
    [HttpPost("datas")]
    public async Task<ApiResult<DictDataDto>> CreateData([FromBody] DictDataSaveRequest request)
    {
        if (!IsAdmin)
        {
            return ApiResult<DictDataDto>.Fail("仅管理员可维护数据字典", 403);
        }

        if (request.WPD_TypeID <= 0)
        {
            return ApiResult<DictDataDto>.Fail("请先选择字典分类");
        }

        var dto = await _service.CreateDataAsync(request, User.Identity?.Name);
        return ApiResult<DictDataDto>.Ok(dto, "已新增");
    }

    /// <summary>修改字典明细</summary>
    [HttpPut("datas/{id:int}")]
    public async Task<ApiResult<DictDataDto>> UpdateData(int id, [FromBody] DictDataSaveRequest request)
    {
        if (!IsAdmin)
        {
            return ApiResult<DictDataDto>.Fail("仅管理员可维护数据字典", 403);
        }

        var dto = await _service.UpdateDataAsync(id, request, User.Identity?.Name);
        return dto is null
            ? ApiResult<DictDataDto>.Fail("记录不存在", 404)
            : ApiResult<DictDataDto>.Ok(dto, "已保存");
    }

    /// <summary>删除字典明细</summary>
    [HttpDelete("datas/{id:int}")]
    public async Task<ApiResult<ApiEmpty>> DeleteData(int id)
    {
        if (!IsAdmin)
        {
            return ApiResult<ApiEmpty>.Fail("仅管理员可维护数据字典", 403);
        }

        return await _service.DeleteDataAsync(id)
            ? ApiResult<ApiEmpty>.Ok(new ApiEmpty(), "已删除")
            : ApiResult<ApiEmpty>.Fail("记录不存在", 404);
    }

    /// <summary>与 SystemController 一致的管理员判定（取 JWT role claim）</summary>
    private bool IsAdmin
    {
        get
        {
            var roles = User.Claims.Where(c => c.Type.EndsWith("/role", StringComparison.OrdinalIgnoreCase))
                .Select(c => c.Value).ToList();
            return roles.Contains("admin");
        }
    }
}
