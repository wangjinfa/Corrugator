using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// TB_IPS_PressRoll
/// </summary>
[SugarTable("TB_IPS_PressRoll", TableDescription = "TB_IPS_PressRoll")]
public class TB_IPS_PressRoll
{
    /// <summary>F_MinWidth</summary>
    [SugarColumn(ColumnName = "F_MinWidth", ColumnDescription = "F_MinWidth")]
    public int F_MinWidth { get; set; }

    /// <summary>F_MaxWidth</summary>
    [SugarColumn(ColumnName = "F_MaxWidth", ColumnDescription = "F_MaxWidth")]
    public int F_MaxWidth { get; set; }

    /// <summary>F_Coef</summary>
    [SugarColumn(ColumnName = "F_Coef", Length = 18, DecimalDigits = 2, ColumnDescription = "F_Coef")]
    public decimal F_Coef { get; set; }

    /// <summary>F_MinPress</summary>
    [SugarColumn(ColumnName = "F_MinPress", Length = 18, DecimalDigits = 2, ColumnDescription = "F_MinPress")]
    public decimal F_MinPress { get; set; }

    /// <summary>F_MaxPress</summary>
    [SugarColumn(ColumnName = "F_MaxPress", Length = 18, DecimalDigits = 2, ColumnDescription = "F_MaxPress")]
    public decimal F_MaxPress { get; set; }

    /// <summary>F_MinWeight</summary>
    [SugarColumn(ColumnName = "F_MinWeight", ColumnDescription = "F_MinWeight")]
    public int F_MinWeight { get; set; }

    /// <summary>F_MaxWeight</summary>
    [SugarColumn(ColumnName = "F_MaxWeight", ColumnDescription = "F_MaxWeight")]
    public int F_MaxWeight { get; set; }

    /// <summary>F_ID</summary>
    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_ID")]
    public int F_ID { get; set; }

}