﻿using Lumina.Excel.GeneratedSheets;

namespace RotationSolver.GameData.Getters;

/// <summary>
/// A class to get content types from the game data.
/// </summary>
internal class ContentTypeGetter(Lumina.GameData gameData)
    : ExcelRowGetter<ContentType>(gameData)
{
    /// <summary>
    /// Determines whether the specified item should be added to the list.
    /// </summary>
    /// <param name="item">The content type item.</param>
    /// <returns><c>true</c> if the item should be added; otherwise, <c>false</c>.</returns>
    protected override bool AddToList(ContentType item)
    {
        var name = item.Name.RawString;
        if (string.IsNullOrEmpty(name) || !name.All(char.IsAscii))
        {
            return false;
        }
        return true;
    }

    /// <summary>
    /// Converts the specified item to code.
    /// </summary>
    /// <param name="item">The content type item.</param>
    /// <returns>The generated code for the item.</returns>
    protected override string ToCode(ContentType item)
    {
        var name = item.Name.RawString.ToPascalCase();
        return $"""
        /// <summary>
        /// 
        /// </summary>
        {name} = {item.RowId},
        """;
    }
}