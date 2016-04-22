using System;
using System.Collections.Generic;
using System.Text;

namespace TRIP_API
{
    public class IMBuildingUsage
    {
        private long lBuildingID = 0;
        private long lUsageID = 0;

        public long BuildingID
        {
            get { return lBuildingID; }
            set { lBuildingID = value; }
        }

        public long UsageID
        {
            get { return lUsageID; }
            set { lUsageID = value; }
        }


    }
}
