using SqlSugar;

namespace Corrugator.Domain.Entities.History;

/// <summary>
/// W_Cruise_ReasonLog
/// </summary>
[SugarTable("W_Cruise_ReasonLog", TableDescription = "W_Cruise_ReasonLog")]
public class W_Cruise_ReasonLog
{
    /// <summary>WF_ID</summary>
    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_ID")]
    public long WF_ID { get; set; }

    /// <summary>WF_Time</summary>
    [SugarColumn(ColumnName = "WF_Time", ColumnDescription = "WF_Time")]
    public DateTime WF_Time { get; set; }

    /// <summary>WF_OrderID</summary>
    [SugarColumn(ColumnName = "WF_OrderID", ColumnDescription = "WF_OrderID")]
    public int WF_OrderID { get; set; }

    /// <summary>WF_OrderMeter</summary>
    [SugarColumn(ColumnName = "WF_OrderMeter", Length = 18, DecimalDigits = 4, ColumnDescription = "WF_OrderMeter")]
    public decimal WF_OrderMeter { get; set; }

    /// <summary>WF_Shift</summary>
    [SugarColumn(ColumnName = "WF_Shift", Length = 255, ColumnDescription = "WF_Shift")]
    public string WF_Shift { get; set; } = default!;

    /// <summary>WF_OrderNo</summary>
    [SugarColumn(ColumnName = "WF_OrderNo", Length = 255, ColumnDescription = "WF_OrderNo")]
    public string WF_OrderNo { get; set; } = default!;

    /// <summary>WF_CutLength</summary>
    [SugarColumn(ColumnName = "WF_CutLength", ColumnDescription = "WF_CutLength")]
    public int WF_CutLength { get; set; }

    /// <summary>WF_CutLengthSpeed</summary>
    [SugarColumn(ColumnName = "WF_CutLengthSpeed", ColumnDescription = "WF_CutLengthSpeed")]
    public int WF_CutLengthSpeed { get; set; }

    /// <summary>WF_PaperCode</summary>
    [SugarColumn(ColumnName = "WF_PaperCode", Length = 255, ColumnDescription = "WF_PaperCode")]
    public string WF_PaperCode { get; set; } = default!;

    /// <summary>WF_PaperCodeSpeed</summary>
    [SugarColumn(ColumnName = "WF_PaperCodeSpeed", ColumnDescription = "WF_PaperCodeSpeed")]
    public int WF_PaperCodeSpeed { get; set; }

    /// <summary>WF_PCodeSF1Speed</summary>
    [SugarColumn(ColumnName = "WF_PCodeSF1Speed", ColumnDescription = "WF_PCodeSF1Speed")]
    public int WF_PCodeSF1Speed { get; set; }

    /// <summary>WF_PCodeSF2Speed</summary>
    [SugarColumn(ColumnName = "WF_PCodeSF2Speed", ColumnDescription = "WF_PCodeSF2Speed")]
    public int WF_PCodeSF2Speed { get; set; }

    /// <summary>WF_PCodeSF3Speed</summary>
    [SugarColumn(ColumnName = "WF_PCodeSF3Speed", ColumnDescription = "WF_PCodeSF3Speed")]
    public int WF_PCodeSF3Speed { get; set; }

    /// <summary>WF_LastSpeed</summary>
    [SugarColumn(ColumnName = "WF_LastSpeed", ColumnDescription = "WF_LastSpeed")]
    public int WF_LastSpeed { get; set; }

    /// <summary>WF_CurSPeed</summary>
    [SugarColumn(ColumnName = "WF_CurSPeed", ColumnDescription = "WF_CurSPeed")]
    public int WF_CurSPeed { get; set; }

    /// <summary>WF_LastCoef</summary>
    [SugarColumn(ColumnName = "WF_LastCoef", Length = 18, DecimalDigits = 4, ColumnDescription = "WF_LastCoef")]
    public decimal WF_LastCoef { get; set; }

    /// <summary>WF_CurCoef</summary>
    [SugarColumn(ColumnName = "WF_CurCoef", Length = 18, DecimalDigits = 4, ColumnDescription = "WF_CurCoef")]
    public decimal WF_CurCoef { get; set; }

    /// <summary>WF_Reason1</summary>
    [SugarColumn(ColumnName = "WF_Reason1", ColumnDescription = "WF_Reason1")]
    public bool WF_Reason1 { get; set; }

    /// <summary>WF_Reason2</summary>
    [SugarColumn(ColumnName = "WF_Reason2", ColumnDescription = "WF_Reason2")]
    public bool WF_Reason2 { get; set; }

    /// <summary>WF_Reason3</summary>
    [SugarColumn(ColumnName = "WF_Reason3", ColumnDescription = "WF_Reason3")]
    public bool WF_Reason3 { get; set; }

    /// <summary>WF_Reason4</summary>
    [SugarColumn(ColumnName = "WF_Reason4", ColumnDescription = "WF_Reason4")]
    public bool WF_Reason4 { get; set; }

    /// <summary>WF_Reason5</summary>
    [SugarColumn(ColumnName = "WF_Reason5", ColumnDescription = "WF_Reason5")]
    public bool WF_Reason5 { get; set; }

    /// <summary>WF_Reason6</summary>
    [SugarColumn(ColumnName = "WF_Reason6", ColumnDescription = "WF_Reason6")]
    public bool WF_Reason6 { get; set; }

    /// <summary>WF_Reason7</summary>
    [SugarColumn(ColumnName = "WF_Reason7", ColumnDescription = "WF_Reason7")]
    public bool WF_Reason7 { get; set; }

    /// <summary>WF_Reason8</summary>
    [SugarColumn(ColumnName = "WF_Reason8", ColumnDescription = "WF_Reason8")]
    public bool WF_Reason8 { get; set; }

    /// <summary>WF_Reason9</summary>
    [SugarColumn(ColumnName = "WF_Reason9", ColumnDescription = "WF_Reason9")]
    public bool WF_Reason9 { get; set; }

    /// <summary>WF_Reason10</summary>
    [SugarColumn(ColumnName = "WF_Reason10", ColumnDescription = "WF_Reason10")]
    public bool WF_Reason10 { get; set; }

    /// <summary>WF_Reason11</summary>
    [SugarColumn(ColumnName = "WF_Reason11", ColumnDescription = "WF_Reason11")]
    public bool WF_Reason11 { get; set; }

    /// <summary>WF_Reason12</summary>
    [SugarColumn(ColumnName = "WF_Reason12", ColumnDescription = "WF_Reason12")]
    public bool WF_Reason12 { get; set; }

    /// <summary>WF_Reason13</summary>
    [SugarColumn(ColumnName = "WF_Reason13", ColumnDescription = "WF_Reason13")]
    public bool WF_Reason13 { get; set; }

    /// <summary>WF_Reason14</summary>
    [SugarColumn(ColumnName = "WF_Reason14", ColumnDescription = "WF_Reason14")]
    public bool WF_Reason14 { get; set; }

    /// <summary>WF_Reason15</summary>
    [SugarColumn(ColumnName = "WF_Reason15", ColumnDescription = "WF_Reason15")]
    public bool WF_Reason15 { get; set; }

    /// <summary>WF_Reason16</summary>
    [SugarColumn(ColumnName = "WF_Reason16", ColumnDescription = "WF_Reason16")]
    public bool WF_Reason16 { get; set; }

    /// <summary>WF_Reason17</summary>
    [SugarColumn(ColumnName = "WF_Reason17", ColumnDescription = "WF_Reason17")]
    public bool WF_Reason17 { get; set; }

    /// <summary>WF_Reason18</summary>
    [SugarColumn(ColumnName = "WF_Reason18", ColumnDescription = "WF_Reason18")]
    public bool WF_Reason18 { get; set; }

    /// <summary>WF_Reason19</summary>
    [SugarColumn(ColumnName = "WF_Reason19", ColumnDescription = "WF_Reason19")]
    public bool WF_Reason19 { get; set; }

    /// <summary>WF_Reason20</summary>
    [SugarColumn(ColumnName = "WF_Reason20", ColumnDescription = "WF_Reason20")]
    public bool WF_Reason20 { get; set; }

    /// <summary>WF_Reason21</summary>
    [SugarColumn(ColumnName = "WF_Reason21", ColumnDescription = "WF_Reason21")]
    public bool WF_Reason21 { get; set; }

    /// <summary>WF_Reason22</summary>
    [SugarColumn(ColumnName = "WF_Reason22", ColumnDescription = "WF_Reason22")]
    public bool WF_Reason22 { get; set; }

    /// <summary>WF_Reason23</summary>
    [SugarColumn(ColumnName = "WF_Reason23", ColumnDescription = "WF_Reason23")]
    public bool WF_Reason23 { get; set; }

    /// <summary>WF_Reason24</summary>
    [SugarColumn(ColumnName = "WF_Reason24", ColumnDescription = "WF_Reason24")]
    public bool WF_Reason24 { get; set; }

    /// <summary>WF_Reason25</summary>
    [SugarColumn(ColumnName = "WF_Reason25", ColumnDescription = "WF_Reason25")]
    public bool WF_Reason25 { get; set; }

    /// <summary>WF_MainReason</summary>
    [SugarColumn(ColumnName = "WF_MainReason", IsNullable = true, ColumnDescription = "WF_MainReason")]
    public int? WF_MainReason { get; set; }

}