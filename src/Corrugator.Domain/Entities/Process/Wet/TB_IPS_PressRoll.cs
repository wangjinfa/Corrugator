using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// W_IPS_PressRoll
/// </summary>
[SugarTable("W_IPS_PressRoll", TableDescription = "W_IPS_PressRoll")]
public class W_IPS_PressRoll
{
    /// <summary>WF_MinWidth</summary>
    [SugarColumn(ColumnName = "WF_MinWidth", ColumnDescription = "WF_MinWidth")]
    public int WF_MinWidth { get; set; }

    /// <summary>WF_MaxWidth</summary>
    [SugarColumn(ColumnName = "WF_MaxWidth", ColumnDescription = "WF_MaxWidth")]
    public int WF_MaxWidth { get; set; }

    /// <summary>WF_Coef</summary>
    [SugarColumn(ColumnName = "WF_Coef", Length = 18, DecimalDigits = 2, ColumnDescription = "WF_Coef")]
    public decimal WF_Coef { get; set; }

    /// <summary>WF_MinPress</summary>
    [SugarColumn(ColumnName = "WF_MinPress", Length = 18, DecimalDigits = 2, ColumnDescription = "WF_MinPress")]
    public decimal WF_MinPress { get; set; }

    /// <summary>WF_MaxPress</summary>
    [SugarColumn(ColumnName = "WF_MaxPress", Length = 18, DecimalDigits = 2, ColumnDescription = "WF_MaxPress")]
    public decimal WF_MaxPress { get; set; }

    /// <summary>WF_MinWeight</summary>
    [SugarColumn(ColumnName = "WF_MinWeight", ColumnDescription = "WF_MinWeight")]
    public int WF_MinWeight { get; set; }

    /// <summary>WF_MaxWeight</summary>
    [SugarColumn(ColumnName = "WF_MaxWeight", ColumnDescription = "WF_MaxWeight")]
    public int WF_MaxWeight { get; set; }

    /// <summary>WF_ID</summary>
    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_ID")]
    public int WF_ID { get; set; }

}