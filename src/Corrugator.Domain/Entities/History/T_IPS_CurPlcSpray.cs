using SqlSugar;

namespace Corrugator.Domain.Entities.History;

/// <summary>
/// PLC冷喷雾
/// </summary>
[SugarTable("W_IPS_CurPlcSpray", TableDescription = "PLC冷喷雾")]
public class W_IPS_CurPlcSpray
{
    /// <summary>WF_Position</summary>
    [SugarColumn(ColumnName = "WF_Position", Length = 50, ColumnDescription = "WF_Position")]
    public string WF_Position { get; set; } = default!;

    /// <summary>WF_IsUse</summary>
    [SugarColumn(ColumnName = "WF_IsUse", ColumnDescription = "WF_IsUse")]
    public bool WF_IsUse { get; set; }

    /// <summary>WF_IsAuto</summary>
    [SugarColumn(ColumnName = "WF_IsAuto", ColumnDescription = "WF_IsAuto")]
    public bool WF_IsAuto { get; set; }

    /// <summary>WF_SetValue</summary>
    [SugarColumn(ColumnName = "WF_SetValue", Length = 18, DecimalDigits = 2, ColumnDescription = "WF_SetValue")]
    public decimal WF_SetValue { get; set; }

    /// <summary>WF_Nozzle1</summary>
    [SugarColumn(ColumnName = "WF_Nozzle1", ColumnDescription = "WF_Nozzle1")]
    public bool WF_Nozzle1 { get; set; }

    /// <summary>WF_Nozzle2</summary>
    [SugarColumn(ColumnName = "WF_Nozzle2", ColumnDescription = "WF_Nozzle2")]
    public bool WF_Nozzle2 { get; set; }

    /// <summary>WF_Nozzle3</summary>
    [SugarColumn(ColumnName = "WF_Nozzle3", ColumnDescription = "WF_Nozzle3")]
    public bool WF_Nozzle3 { get; set; }

    /// <summary>WF_Nozzle4</summary>
    [SugarColumn(ColumnName = "WF_Nozzle4", ColumnDescription = "WF_Nozzle4")]
    public bool WF_Nozzle4 { get; set; }

    /// <summary>WF_Nozzle5</summary>
    [SugarColumn(ColumnName = "WF_Nozzle5", ColumnDescription = "WF_Nozzle5")]
    public bool WF_Nozzle5 { get; set; }

    /// <summary>WF_Nozzle6</summary>
    [SugarColumn(ColumnName = "WF_Nozzle6", ColumnDescription = "WF_Nozzle6")]
    public bool WF_Nozzle6 { get; set; }

    /// <summary>WF_Nozzle7</summary>
    [SugarColumn(ColumnName = "WF_Nozzle7", ColumnDescription = "WF_Nozzle7")]
    public bool WF_Nozzle7 { get; set; }

    /// <summary>WF_Nozzle8</summary>
    [SugarColumn(ColumnName = "WF_Nozzle8", ColumnDescription = "WF_Nozzle8")]
    public bool WF_Nozzle8 { get; set; }

    /// <summary>WF_Nozzle9</summary>
    [SugarColumn(ColumnName = "WF_Nozzle9", ColumnDescription = "WF_Nozzle9")]
    public bool WF_Nozzle9 { get; set; }

    /// <summary>WF_Nozzle10</summary>
    [SugarColumn(ColumnName = "WF_Nozzle10", ColumnDescription = "WF_Nozzle10")]
    public bool WF_Nozzle10 { get; set; }

    /// <summary>WF_Nozzle11</summary>
    [SugarColumn(ColumnName = "WF_Nozzle11", ColumnDescription = "WF_Nozzle11")]
    public bool WF_Nozzle11 { get; set; }

    /// <summary>WF_Nozzle12</summary>
    [SugarColumn(ColumnName = "WF_Nozzle12", ColumnDescription = "WF_Nozzle12")]
    public bool WF_Nozzle12 { get; set; }

    /// <summary>WF_Nozzle13</summary>
    [SugarColumn(ColumnName = "WF_Nozzle13", ColumnDescription = "WF_Nozzle13")]
    public bool WF_Nozzle13 { get; set; }

    /// <summary>WF_Nozzle14</summary>
    [SugarColumn(ColumnName = "WF_Nozzle14", ColumnDescription = "WF_Nozzle14")]
    public bool WF_Nozzle14 { get; set; }

    /// <summary>WF_ID</summary>
    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_ID")]
    public long WF_ID { get; set; }

}