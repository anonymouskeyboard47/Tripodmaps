using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace TRIP_API
{
    public class IMEventLog
    {
        private int lEventLogID = 0;
        private string strSource = "";
        private string strLog = "";
        private string strEvent = "";
        private string errMessage = "";
        private EventLogEntryType evetypeEventType;

         //sSource = "dotNET Sample App";
         //           sLog = "Application";
         //           sEvent = "Sample Event";


        #region "Properties"


        public int EventLogID
        {
            get { return lEventLogID; }
            set { lEventLogID = value; }
        }

        public string Source
        {
            get { return strSource; }
            set { strSource = value; }
        }

        public string Log
        {
            get { return strLog; }
            set { strLog = value; }
        }

        public string Event
        {
            get { return strEvent; }
            set { strEvent = value; }
        }

        public EventLogEntryType EveEventType
        {
            get { return evetypeEventType; }
            set { evetypeEventType = value; }
        }


        #endregion


        #region "EventLoggingMethods"

        
            public bool WriteEvent()
        {
            try
            {

                if (!EventLog.SourceExists(strSource))
                {

                    if (!EventLog.SourceExists(strSource))
                        EventLog.CreateEventSource(strSource, strLog);

                    EventLog.WriteEntry(strSource, strEvent);
                    EventLog.WriteEntry(strSource, strEvent, evetypeEventType, lEventLogID);

                    return false;
                }

                return false;
            }


            catch (Exception ex)
            {
                errMessage = ex.Message + " : Source = " + ex.Source;
                return false;
            }

            finally
            {
                
            }

        }

        #endregion


    }
}
