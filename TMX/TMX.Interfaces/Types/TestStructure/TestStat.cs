/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/19/2012
 * Time: 2:49 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces
{
    using System;
    
    /// <summary>
    /// Description of TestStat.
    /// </summary>

    public struct TestStat : IEquatable<TestStat>
    {
        public int DbId { get; set; }
        public int All;
        public int Passed;
        public int Failed;
        public int NotTested;
        public double TimeSpent;
        public int PassedButWithBadSmell;
        
        
        int member; // this is just an example member, replace it with your own struct members!
        
        #region Equals and GetHashCode implementation
        // The code in this region is useful if you want to use this structure in collections.
        // If you don't need it, you can just remove the region and the ": IEquatable<TestStat>" declaration.
        
        public override bool Equals(object obj)
		{
			if (obj is TestStat)
				return Equals((TestStat)obj); // use Equals method below
			return false;
		}
        
        public bool Equals(TestStat other)
        {
            // add comparisions for all members here
            return this.member == other.member;
        }
        
        public override int GetHashCode()
        {
            // combine the hash codes of all members here (e.g. with XOR operator ^)
            return member.GetHashCode();
        }
        
        public static bool operator ==(TestStat left, TestStat right)
        {
            return left.Equals(right);
        }
        
        public static bool operator !=(TestStat left, TestStat right)
        {
            return !left.Equals(right);
        }
        #endregion
        
        //public void SetTimeSpent
    }
}
