using SqlSugar;

namespace Corrugator.Domain.Entities.MasterData;

/// <summary>
/// 当前班组表
/// </summary>
[SugarTable("S_CurrentShift", TableDescription = "当前班组表")]
public class S_CurrentShift
{
    /// <summary>当前班组</summary>
    [SugarColumn(ColumnName = "SCS_ClassId", IsNullable = true, ColumnDescription = "当前班组")]
    public int? SCS_ClassId { get; set; }

    /// <summary>SCS_P04TID</summary>
    [SugarColumn(ColumnName = "SCS_P04TID", IsNullable = true, ColumnDescription = "SCS_P04TID")]
    public int? SCS_P04TID { get; set; }

    /// <summary>SCS_ShiftNum</summary>
    [SugarColumn(ColumnName = "SCS_ShiftNum", Length = 10, IsNullable = true, ColumnDescription = "SCS_ShiftNum")]
    public string? SCS_ShiftNum { get; set; }

    /// <summary>SCS_Shift</summary>
    [SugarColumn(ColumnName = "SCS_Shift", Length = 50, IsNullable = true, ColumnDescription = "SCS_Shift")]
    public string? SCS_Shift { get; set; }

    /// <summary>SCS_LastClassId</summary>
    [SugarColumn(ColumnName = "SCS_LastClassId", IsNullable = true, ColumnDescription = "SCS_LastClassId")]
    public int? SCS_LastClassId { get; set; }

    /// <summary>SCS_LastP04TID</summary>
    [SugarColumn(ColumnName = "SCS_LastP04TID", IsNullable = true, ColumnDescription = "SCS_LastP04TID")]
    public int? SCS_LastP04TID { get; set; }

    /// <summary>SCS_LastShiftNum</summary>
    [SugarColumn(ColumnName = "SCS_LastShiftNum", Length = 10, IsNullable = true, ColumnDescription = "SCS_LastShiftNum")]
    public string? SCS_LastShiftNum { get; set; }

    /// <summary>SCS_LastShift</summary>
    [SugarColumn(ColumnName = "SCS_LastShift", Length = 50, IsNullable = true, ColumnDescription = "SCS_LastShift")]
    public string? SCS_LastShift { get; set; }

    /// <summary>SCS_ChangeTime</summary>
    [SugarColumn(ColumnName = "SCS_ChangeTime", IsNullable = true, ColumnDescription = "SCS_ChangeTime")]
    public DateTime? SCS_ChangeTime { get; set; }

    /// <summary>当前使用楞型</summary>
    [SugarColumn(ColumnName = "SCS_SF1CurUseFluteSF1", Length = 50, IsNullable = true, ColumnDescription = "当前使用楞型")]
    public string? SCS_SF1CurUseFluteSF1 { get; set; }

    /// <summary>当前使用楞型</summary>
    [SugarColumn(ColumnName = "SCS_SF2CurUseFluteSF2", Length = 50, IsNullable = true, ColumnDescription = "当前使用楞型")]
    public string? SCS_SF2CurUseFluteSF2 { get; set; }

    /// <summary>当前使用楞型</summary>
    [SugarColumn(ColumnName = "SCS_SF3CurUseFluteSF3", Length = 50, IsNullable = true, ColumnDescription = "当前使用楞型")]
    public string? SCS_SF3CurUseFluteSF3 { get; set; }

    /// <summary>SCS_Id</summary>
    [SugarColumn(ColumnName = "SCS_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "SCS_Id")]
    public int SCS_Id { get; set; }

}