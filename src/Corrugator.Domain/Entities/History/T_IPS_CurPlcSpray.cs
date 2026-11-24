using SqlSugar;

namespace Corrugator.Domain.Entities.History;

/// <summary>
/// PLC冷喷雾
/// </summary>
[SugarTable("T_IPS_CurPlcSpray", TableDescription = "PLC冷喷雾")]
public class T_IPS_CurPlcSpray
{
    /// <summary>F_Position</summary>
    [SugarColumn(ColumnName = "F_Position", Length = 50, ColumnDescription = "F_Position")]
    public string F_Position { get; set; } = default!;

    /// <summary>F_IsUse</summary>
    [SugarColumn(ColumnName = "F_IsUse", ColumnDescription = "F_IsUse")]
    public bool F_IsUse { get; set; }

    /// <summary>F_IsAuto</summary>
    [SugarColumn(ColumnName = "F_IsAuto", ColumnDescription = "F_IsAuto")]
    public bool F_IsAuto { get; set; }

    /// <summary>F_SetValue</summary>
    [SugarColumn(ColumnName = "F_SetValue", Length = 18, DecimalDigits = 2, ColumnDescription = "F_SetValue")]
    public decimal F_SetValue { get; set; }

    /// <summary>F_Nozzle1</summary>
    [SugarColumn(ColumnName = "F_Nozzle1", ColumnDescription = "F_Nozzle1")]
    public bool F_Nozzle1 { get; set; }

    /// <summary>F_Nozzle2</summary>
    [SugarColumn(ColumnName = "F_Nozzle2", ColumnDescription = "F_Nozzle2")]
    public bool F_Nozzle2 { get; set; }

    /// <summary>F_Nozzle3</summary>
    [SugarColumn(ColumnName = "F_Nozzle3", ColumnDescription = "F_Nozzle3")]
    public bool F_Nozzle3 { get; set; }

    /// <summary>F_Nozzle4</summary>
    [SugarColumn(ColumnName = "F_Nozzle4", ColumnDescription = "F_Nozzle4")]
    public bool F_Nozzle4 { get; set; }

    /// <summary>F_Nozzle5</summary>
    [SugarColumn(ColumnName = "F_Nozzle5", ColumnDescription = "F_Nozzle5")]
    public bool F_Nozzle5 { get; set; }

    /// <summary>F_Nozzle6</summary>
    [SugarColumn(ColumnName = "F_Nozzle6", ColumnDescription = "F_Nozzle6")]
    public bool F_Nozzle6 { get; set; }

    /// <summary>F_Nozzle7</summary>
    [SugarColumn(ColumnName = "F_Nozzle7", ColumnDescription = "F_Nozzle7")]
    public bool F_Nozzle7 { get; set; }

    /// <summary>F_Nozzle8</summary>
    [SugarColumn(ColumnName = "F_Nozzle8", ColumnDescription = "F_Nozzle8")]
    public bool F_Nozzle8 { get; set; }

    /// <summary>F_Nozzle9</summary>
    [SugarColumn(ColumnName = "F_Nozzle9", ColumnDescription = "F_Nozzle9")]
    public bool F_Nozzle9 { get; set; }

    /// <summary>F_Nozzle10</summary>
    [SugarColumn(ColumnName = "F_Nozzle10", ColumnDescription = "F_Nozzle10")]
    public bool F_Nozzle10 { get; set; }

    /// <summary>F_Nozzle11</summary>
    [SugarColumn(ColumnName = "F_Nozzle11", ColumnDescription = "F_Nozzle11")]
    public bool F_Nozzle11 { get; set; }

    /// <summary>F_Nozzle12</summary>
    [SugarColumn(ColumnName = "F_Nozzle12", ColumnDescription = "F_Nozzle12")]
    public bool F_Nozzle12 { get; set; }

    /// <summary>F_Nozzle13</summary>
    [SugarColumn(ColumnName = "F_Nozzle13", ColumnDescription = "F_Nozzle13")]
    public bool F_Nozzle13 { get; set; }

    /// <summary>F_Nozzle14</summary>
    [SugarColumn(ColumnName = "F_Nozzle14", ColumnDescription = "F_Nozzle14")]
    public bool F_Nozzle14 { get; set; }

    /// <summary>F_ID</summary>
    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_ID")]
    public long F_ID { get; set; }

}