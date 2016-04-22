using System;
using System.Collections.Generic;
using System.Text;

namespace TRIP_API
{
    public class IMPlotUsage
    {
        private long lPlotID = 0;
        private long lUsageID = 0;

        public long PlotID
        {
            get { return lPlotID; }
            set { lPlotID = value; }
        }

        public long UsageID
        {
            get { return lUsageID; }
            set { lUsageID = value; }
        }

    }
}
