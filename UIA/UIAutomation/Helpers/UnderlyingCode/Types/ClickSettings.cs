/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/30/2013
 * Time: 4:07 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    /// <summary>
    /// Description of ClickSettings.
    /// </summary>
    public struct ClickSettings //: IEquatable<ClickSettings>
    {
        public bool RightClick { get; set; }
        public bool MidClick { get; set; }
        public bool Alt { get; set; }
        public bool Shift { get; set; }
        public bool Ctrl { get; set; }
        public bool inSequence { get; set; }
        public bool DoubleClick { get; set; }
        public int DoubleClickInterval { get; set; }
        public int RelativeX { get; set; }
        public int RelativeY { get; set; }
        
//        int member; // this is just an example member, replace it with your own struct members!
//        
//        #region Equals and GetHashCode implementation
//        // The code in this region is useful if you want to use this structure in collections.
//        // If you don't need it, you can just remove the region and the ": IEquatable<ClickSettings>" declaration.
//        
//        public override bool Equals(object obj)
//        {
//            if (obj is ClickSettings)
//                return Equals((ClickSettings)obj); // use Equals method below
//            else
//                return false;
//        }
//        
//        public bool Equals(ClickSettings other)
//        {
//            // add comparisions for all members here
//            return this.member == other.member;
//        }
//        
//        public override int GetHashCode()
//        {
//            // combine the hash codes of all members here (e.g. with XOR operator ^)
//            return member.GetHashCode();
//        }
//        
//        public static bool operator ==(ClickSettings left, ClickSettings right)
//        {
//            return left.Equals(right);
//        }
//        
//        public static bool operator !=(ClickSettings left, ClickSettings right)
//        {
//            return !left.Equals(right);
//        }
//        #endregion
    }
}
