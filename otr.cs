using OTR.Interface;
using System;
namespace OpenMessage
{
    class otr
    {
        public OTRSessionManager otrSess;
        public string _uniqueID;

        public void createSession(string uid)
        {
            otrSess = new OTRSessionManager(uid);
            otrSess.OnOTREvent += new OTREventHandler(OnEvent);
        }

        public string generateSessionID()
        {
            string finalID = null;
            var rnd = new Random();
            var firstID = rnd.Next(99999);
            var secondID = rnd.Next(99);
            var thirdID = rnd.Next(9999999);
            var rand = new Random(Guid.NewGuid().GetHashCode() + firstID + secondID + thirdID);
            var combID = rand.Next(999999);
            var combID2 = rand.Next(999999999);
            byte[] intBytes = BitConverter.GetBytes(combID);
            Array.Reverse(intBytes);
            byte[] result = intBytes;
            var newEnc = new encryption();
            finalID = encryption.ComputeHash(combID2.ToString(), "SHA512", result);
            return finalID;
        }

        public void OnEvent(object source, OTREventArgs e)
        {
            switch (e.GetOTREvent())
            {
                case OTR_EVENT.MESSAGE:

                    break;

                case OTR_EVENT.SEND:

                    break;
                case OTR_EVENT.ERROR:

                    break;
                case OTR_EVENT.READY:

                    break;
                case OTR_EVENT.DEBUG:

                    break;
                case OTR_EVENT.EXTRA_KEY_REQUEST:

                    break;
                case OTR_EVENT.SMP_MESSAGE:

                    break;
                case OTR_EVENT.CLOSED:

                    break;

            }
        }

        void SendDataOnNetwork(string my_unique_id, string otr_data)
        {
            otrSess.ProcessOTRMessage(my_unique_id, otr_data);
        }
    }
}