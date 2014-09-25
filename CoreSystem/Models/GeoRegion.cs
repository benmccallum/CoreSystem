namespace CoreSystem.Models
{
    /// <summary>
    /// Representing a region returned by a GEOIP lookup
    /// </summary>
    public class GEORegion
    {
        /// <summary>
        /// Region Name
        /// </summary>
        public string RegionName { get; set; }

        /// <summary>
        /// Region ID, this will match the region ID in EPG
        /// </summary>
        public int RegionID { get; set; }

        /// <summary>
        /// The GMT offset of the region
        /// </summary>
        public double GMTOffset { get; set; }

        /// <summary>
        /// State
        /// </summary>
        public string StateName { get; set; }

        /// <summary>
        /// If the region has data and is valid
        /// </summary>
        public bool HasData { get { return this.RegionID > 0; } }
    }
}