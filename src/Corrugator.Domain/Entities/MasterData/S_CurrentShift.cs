using SqlSugar;

namespace Corrugator.Domain.Entities.MasterData;

/// <summary>
/// 当前班组表
/// </summary>
[SugarTable("W_CurrentShift", TableDescription = "当前班组表")]
public class W_CurrentShift
{
    /// <summary>当前班组</summary>
    [SugarColumn(ColumnName = "WSCS_ClassId", IsNullable = true, ColumnDescription = "当前班组")]
    public int? WSCS_ClassId { get; set; }

    /// <summary>WSCS_P04TID</summary>
    [SugarColumn(ColumnName = "WSCS_P04TID", IsNullable = true, ColumnDescription = "WSCS_P04TID")]
    public int? WSCS_P04TID { get; set; }

    /// <summary>WSCS_ShiftNum</summary>
    [SugarColumn(ColumnName = "WSCS_ShiftNum", Length = 10, IsNullable = true, ColumnDescription = "WSCS_ShiftNum")]
    public string? WSCS_ShiftNum { get; set; }

    /// <summary>WSCS_Shift</summary>
    [SugarColumn(ColumnName = "WSCS_Shift", Length = 50, IsNullable = true, ColumnDescription = "WSCS_Shift")]
    public string? WSCS_Shift { get; set; }

    /// <summary>WSCS_LastClassId</summary>
    [SugarColumn(ColumnName = "WSCS_LastClassId", IsNullable = true, ColumnDescription = "WSCS_LastClassId")]
    public int? WSCS_LastClassId { get; set; }

    /// <summary>WSCS_LastP04TID</summary>
    [SugarColumn(ColumnName = "WSCS_LastP04TID", IsNullable = true, ColumnDescription = "WSCS_LastP04TID")]
    public int? WSCS_LastP04TID { get; set; }

    /// <summary>WSCS_LastShiftNum</summary>
    [SugarColumn(ColumnName = "WSCS_LastShiftNum", Length = 10, IsNullable = true, ColumnDescription = "WSCS_LastShiftNum")]
    public string? WSCS_LastShiftNum { get; set; }

    /// <summary>WSCS_LastShift</summary>
    [SugarColumn(ColumnName = "WSCS_LastShift", Length = 50, IsNullable = true, ColumnDescription = "WSCS_LastShift")]
    public string? WSCS_LastShift { get; set; }

    /// <summary>WSCS_ChangeTime</summary>
    [SugarColumn(ColumnName = "WSCS_ChangeTime", IsNullable = true, ColumnDescription = "WSCS_ChangeTime")]
    public DateTime? WSCS_ChangeTime { get; set; }

    /// <summary>当前使用楞型</summary>
    [SugarColumn(ColumnName = "WSCS_SF1CurUseFluteSF1", Length = 50, IsNullable = true, ColumnDescription = "当前使用楞型")]
    public string? WSCS_SF1CurUseFluteSF1 { get; set; }

    /// <summary>当前使用楞型</summary>
    [SugarColumn(ColumnName = "WSCS_SF2CurUseFluteSF2", Length = 50, IsNullable = true, ColumnDescription = "当前使用楞型")]
    public string? WSCS_SF2CurUseFluteSF2 { get; set; }

    /// <summary>当前使用楞型</summary>
    [SugarColumn(ColumnName = "WSCS_SF3CurUseFluteSF3", Length = 50, IsNullable = true, ColumnDescription = "当前使用楞型")]
    public string? WSCS_SF3CurUseFluteSF3 { get; set; }

    /// <summary>WSCS_Id</summary>
    [SugarColumn(ColumnName = "WSCS_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WSCS_Id")]
    public int WSCS_Id { get; set; }

}