/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 1/11/2014
 * Time: 6:38 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    
    /// <summary>
    /// Description of ScreenshotSquare.
    /// </summary>
    public struct ScreenshotRect // : IEquatable<ScreenshotRect>
    {
//        int member; // this is just an example member, replace it with your own struct members!
//        
//        #region Equals and GetHashCode implementation
//        // The code in this region is useful if you want to use this structure in collections.
//        // If you don't need it, you can just remove the region and the ": IEquatable<ScreenshotSquare>" declaration.
//        
//        public override bool Equals(object obj)
//        {
//            if (obj is ScreenshotSquare)
//                return Equals((ScreenshotSquare)obj); // use Equals method below
//            else
//                return false;
//        }
//        
//        public bool Equals(ScreenshotSquare other)
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
//        public static bool operator ==(ScreenshotSquare left, ScreenshotSquare right)
//        {
//            return left.Equals(right);
//        }
//        
//        public static bool operator !=(ScreenshotSquare left, ScreenshotSquare right)
//        {
//            return !left.Equals(right);
//        }
//        #endregion
        
        public int Left { get; set; }
        public int Top { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
    }
}
