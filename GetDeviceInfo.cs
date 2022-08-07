using System;
using System.Management;
using System.Text;

namespace LoginPage
{
    public class GetDeviceInfo
    {
        //Device Information Variables
        private string mBB, proserial, hdserial;
        private Byte[] OBKData = new Byte[30];
        private Byte[] CBKData = new Byte[30];

        public GetDeviceInfo() 
        {
            mBB = getMotherBoardSerial();
            proserial = getProcessorID();
            hdserial = getHardDiskID();
        }

        //Get device information
        public string DeviceInfo()
        {
            Byte[] MBB_Buffer = Encoding.ASCII.GetBytes(mBB);
            Byte[] Proc_Buffer = Encoding.ASCII.GetBytes(proserial);
            Byte[] HDD_Buffer = Encoding.ASCII.GetBytes(hdserial);

            for (int i = 0; i < 10; i++)
                OBKData[i] = MBB_Buffer[i];

            for (int i = 10, j = 0; i < 20; i++, j++)
                OBKData[i] = Proc_Buffer[j];

            for (int i = 20, j = 0; i < 30; i++, j++)
                OBKData[i] = HDD_Buffer[j];

            for (int i = 0; i < 30; i++)
            {
                int temp1 = (int)OBKData[i] + 7;
                CBKData[i] = (Byte)temp1;
            }
            var str = System.Text.Encoding.Default.GetString(CBKData);
            return str;
        }

        private string getMotherBoardSerial()
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
            ManagementObjectCollection moc = mos.Get();
            string motherBoard = "";
            foreach (ManagementObject mo in moc)
            {
                motherBoard = (string)mo["SerialNumber"];
            }
            return motherBoard;
        }

        private string getProcessorID()
        {
            ManagementObjectSearcher mbs = new ManagementObjectSearcher("Select * From Win32_processor");
            ManagementObjectCollection mbsList = mbs.Get();
            string id = "";
            foreach (ManagementObject mo in mbsList)
            {
                id = mo["ProcessorID"].ToString();
            }
            return id;
        }

        private string getHardDiskID()
        {
            string hddID = null;
            ManagementClass mc = new ManagementClass("Win32_LogicalDisk");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject strt in moc)
            {
                hddID += Convert.ToString(strt["VolumeSerialNumber"]);
            }
            return hddID.Trim().ToString();
        }
    }
}
