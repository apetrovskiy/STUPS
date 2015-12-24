// (c) Copyright Microsoft, 2012.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.



using System;
using System.Runtime.InteropServices;

namespace System.Windows.Automation.Text
{
    [Guid("B6C08F15-AA5E-4754-9E4C-AA279D3F36D4")]
    [ComVisible(true)]
    public enum AnimationStyle
    {
        None = 0,
        LasVegasLights = 1,
        BlinkingBackground = 2,
        SparkleText = 3,
        MarchingBlackAnts = 4,
        MarchingRedAnts = 5,
        Shimmer = 6,
        Other = -1,
    }

    [Guid("814FAC6C-F8DE-4682-AF5F-37C4F720990C")]
    [ComVisible(true)]
    public enum BulletStyle
    {
        None = 0,
        HollowRoundBullet = 1,
        FilledRoundBullet = 2,
        HollowSquareBullet = 3,
        FilledSquareBullet = 4,
        DashBullet = 5,
        Other = -1
    }

    [Guid("4E33C74B-7848-4f1e-B819-A0D866C2EA1F")]
    [ComVisible(true)]
    public enum CapStyle
    {
        None = 0,
        SmallCap = 1,
        AllCap = 2,
        AllPetiteCaps = 3,
        PetiteCaps = 4,
        Unicase = 5,
        Titling = 6,
        Other = -1,
    }

    [Guid("2E22CC6B-7C34-4002-91AA-E103A09D1027")]
    [Flags]
    [ComVisible(true)]
    public enum FlowDirections
    {
        Default = 0,
        RightToLeft = 1,
        BottomToTop = 2,
        Vertical = 4
    }

    [Guid("1FBE7021-A1E4-4e9b-BE94-2C7DFA59D5DD")]
    [ComVisible(true)]
    public enum HorizontalTextAlignment
    {
        Left,
        Centered,
        Right,
        Justified
    }

    [Guid("1F57B37D-CB59-43f4-95E0-7C9E40DB427E")]
    [ComVisible(true)]
    [Flags]
    public enum OutlineStyles
    {
        None = 0,
        Outline = 1,
        Shadow = 2,
        Engraved = 4,
        Embossed = 8,
    }

    [Guid("909D8633-2941-428e-A549-C752E2FC078C")]
    [ComVisible(true)]
    public enum TextDecorationLineStyle
    {
        None = 0,
        Single = 1,
        WordsOnly = 2,
        Double = 3,
        Dot = 4,
        Dash = 5,
        DashDot = 6,
        DashDotDot = 7,
        Wavy = 8,
        ThickSingle = 9,
        DoubleWavy = 11,
        ThickWavy = 12,
        LongDash = 13,
        ThickDash = 14,
        ThickDashDot = 15,
        ThickDashDotDot = 16,
        ThickDot = 17,
        ThickLongDash = 18,
        Other = -1,
    }

    [Guid("62242CAC-9CD0-4364-813D-4F0A36DD842D")]
    [ComVisible(true)]
    public enum TextPatternRangeEndpoint
    {
        Start,
        End
    }

    [ComVisible(true)]
    [Guid("A044E5C8-FC20-4747-8CC8-1487F9CBB680")]
    public enum TextUnit
    {
        Character,
        Format,
        Word,
        Line,
        Paragraph,
        Page,
        Document
    }
}
