using SqlSugar;

namespace Corrugator.Domain.Entities.History;

/// <summary>
/// T_Cruise_ReasonLog
/// </summary>
[SugarTable("T_Cruise_ReasonLog", TableDescription = "T_Cruise_ReasonLog")]
public class T_Cruise_ReasonLog
{
    /// <summary>F_ID</summary>
    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_ID")]
    public long F_ID { get; set; }

    /// <summary>F_Time</summary>
    [SugarColumn(ColumnName = "F_Time", ColumnDescription = "F_Time")]
    public DateTime F_Time { get; set; }

    /// <summary>F_OrderID</summary>
    [SugarColumn(ColumnName = "F_OrderID", ColumnDescription = "F_OrderID")]
    public int F_OrderID { get; set; }

    /// <summary>F_OrderMeter</summary>
    [SugarColumn(ColumnName = "F_OrderMeter", Length = 18, DecimalDigits = 4, ColumnDescription = "F_OrderMeter")]
    public decimal F_OrderMeter { get; set; }

    /// <summary>F_Shift</summary>
    [SugarColumn(ColumnName = "F_Shift", Length = 255, ColumnDescription = "F_Shift")]
    public string F_Shift { get; set; } = default!;

    /// <summary>F_OrderNo</summary>
    [SugarColumn(ColumnName = "F_OrderNo", Length = 255, ColumnDescription = "F_OrderNo")]
    public string F_OrderNo { get; set; } = default!;

    /// <summary>F_CutLength</summary>
    [SugarColumn(ColumnName = "F_CutLength", ColumnDescription = "F_CutLength")]
    public int F_CutLength { get; set; }

    /// <summary>F_CutLengthSpeed</summary>
    [SugarColumn(ColumnName = "F_CutLengthSpeed", ColumnDescription = "F_CutLengthSpeed")]
    public int F_CutLengthSpeed { get; set; }

    /// <summary>F_PaperCode</summary>
    [SugarColumn(ColumnName = "F_PaperCode", Length = 255, ColumnDescription = "F_PaperCode")]
    public string F_PaperCode { get; set; } = default!;

    /// <summary>F_PaperCodeSpeed</summary>
    [SugarColumn(ColumnName = "F_PaperCodeSpeed", ColumnDescription = "F_PaperCodeSpeed")]
    public int F_PaperCodeSpeed { get; set; }

    /// <summary>F_PCodeSF1Speed</summary>
    [SugarColumn(ColumnName = "F_PCodeSF1Speed", ColumnDescription = "F_PCodeSF1Speed")]
    public int F_PCodeSF1Speed { get; set; }

    /// <summary>F_PCodeSF2Speed</summary>
    [SugarColumn(ColumnName = "F_PCodeSF2Speed", ColumnDescription = "F_PCodeSF2Speed")]
    public int F_PCodeSF2Speed { get; set; }

    /// <summary>F_PCodeSF3Speed</summary>
    [SugarColumn(ColumnName = "F_PCodeSF3Speed", ColumnDescription = "F_PCodeSF3Speed")]
    public int F_PCodeSF3Speed { get; set; }

    /// <summary>F_LastSpeed</summary>
    [SugarColumn(ColumnName = "F_LastSpeed", ColumnDescription = "F_LastSpeed")]
    public int F_LastSpeed { get; set; }

    /// <summary>F_CurSPeed</summary>
    [SugarColumn(ColumnName = "F_CurSPeed", ColumnDescription = "F_CurSPeed")]
    public int F_CurSPeed { get; set; }

    /// <summary>F_LastCoef</summary>
    [SugarColumn(ColumnName = "F_LastCoef", Length = 18, DecimalDigits = 4, ColumnDescription = "F_LastCoef")]
    public decimal F_LastCoef { get; set; }

    /// <summary>F_CurCoef</summary>
    [SugarColumn(ColumnName = "F_CurCoef", Length = 18, DecimalDigits = 4, ColumnDescription = "F_CurCoef")]
    public decimal F_CurCoef { get; set; }

    /// <summary>F_Reason1</summary>
    [SugarColumn(ColumnName = "F_Reason1", ColumnDescription = "F_Reason1")]
    public bool F_Reason1 { get; set; }

    /// <summary>F_Reason2</summary>
    [SugarColumn(ColumnName = "F_Reason2", ColumnDescription = "F_Reason2")]
    public bool F_Reason2 { get; set; }

    /// <summary>F_Reason3</summary>
    [SugarColumn(ColumnName = "F_Reason3", ColumnDescription = "F_Reason3")]
    public bool F_Reason3 { get; set; }

    /// <summary>F_Reason4</summary>
    [SugarColumn(ColumnName = "F_Reason4", ColumnDescription = "F_Reason4")]
    public bool F_Reason4 { get; set; }

    /// <summary>F_Reason5</summary>
    [SugarColumn(ColumnName = "F_Reason5", ColumnDescription = "F_Reason5")]
    public bool F_Reason5 { get; set; }

    /// <summary>F_Reason6</summary>
    [SugarColumn(ColumnName = "F_Reason6", ColumnDescription = "F_Reason6")]
    public bool F_Reason6 { get; set; }

    /// <summary>F_Reason7</summary>
    [SugarColumn(ColumnName = "F_Reason7", ColumnDescription = "F_Reason7")]
    public bool F_Reason7 { get; set; }

    /// <summary>F_Reason8</summary>
    [SugarColumn(ColumnName = "F_Reason8", ColumnDescription = "F_Reason8")]
    public bool F_Reason8 { get; set; }

    /// <summary>F_Reason9</summary>
    [SugarColumn(ColumnName = "F_Reason9", ColumnDescription = "F_Reason9")]
    public bool F_Reason9 { get; set; }

    /// <summary>F_Reason10</summary>
    [SugarColumn(ColumnName = "F_Reason10", ColumnDescription = "F_Reason10")]
    public bool F_Reason10 { get; set; }

    /// <summary>F_Reason11</summary>
    [SugarColumn(ColumnName = "F_Reason11", ColumnDescription = "F_Reason11")]
    public bool F_Reason11 { get; set; }

    /// <summary>F_Reason12</summary>
    [SugarColumn(ColumnName = "F_Reason12", ColumnDescription = "F_Reason12")]
    public bool F_Reason12 { get; set; }

    /// <summary>F_Reason13</summary>
    [SugarColumn(ColumnName = "F_Reason13", ColumnDescription = "F_Reason13")]
    public bool F_Reason13 { get; set; }

    /// <summary>F_Reason14</summary>
    [SugarColumn(ColumnName = "F_Reason14", ColumnDescription = "F_Reason14")]
    public bool F_Reason14 { get; set; }

    /// <summary>F_Reason15</summary>
    [SugarColumn(ColumnName = "F_Reason15", ColumnDescription = "F_Reason15")]
    public bool F_Reason15 { get; set; }

    /// <summary>F_Reason16</summary>
    [SugarColumn(ColumnName = "F_Reason16", ColumnDescription = "F_Reason16")]
    public bool F_Reason16 { get; set; }

    /// <summary>F_Reason17</summary>
    [SugarColumn(ColumnName = "F_Reason17", ColumnDescription = "F_Reason17")]
    public bool F_Reason17 { get; set; }

    /// <summary>F_Reason18</summary>
    [SugarColumn(ColumnName = "F_Reason18", ColumnDescription = "F_Reason18")]
    public bool F_Reason18 { get; set; }

    /// <summary>F_Reason19</summary>
    [SugarColumn(ColumnName = "F_Reason19", ColumnDescription = "F_Reason19")]
    public bool F_Reason19 { get; set; }

    /// <summary>F_Reason20</summary>
    [SugarColumn(ColumnName = "F_Reason20", ColumnDescription = "F_Reason20")]
    public bool F_Reason20 { get; set; }

    /// <summary>F_Reason21</summary>
    [SugarColumn(ColumnName = "F_Reason21", ColumnDescription = "F_Reason21")]
    public bool F_Reason21 { get; set; }

    /// <summary>F_Reason22</summary>
    [SugarColumn(ColumnName = "F_Reason22", ColumnDescription = "F_Reason22")]
    public bool F_Reason22 { get; set; }

    /// <summary>F_Reason23</summary>
    [SugarColumn(ColumnName = "F_Reason23", ColumnDescription = "F_Reason23")]
    public bool F_Reason23 { get; set; }

    /// <summary>F_Reason24</summary>
    [SugarColumn(ColumnName = "F_Reason24", ColumnDescription = "F_Reason24")]
    public bool F_Reason24 { get; set; }

    /// <summary>F_Reason25</summary>
    [SugarColumn(ColumnName = "F_Reason25", ColumnDescription = "F_Reason25")]
    public bool F_Reason25 { get; set; }

    /// <summary>F_MainReason</summary>
    [SugarColumn(ColumnName = "F_MainReason", IsNullable = true, ColumnDescription = "F_MainReason")]
    public int? F_MainReason { get; set; }

}