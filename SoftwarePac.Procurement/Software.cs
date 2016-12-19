namespace SoftwarePac.Procurement
{
    public class Software
    {
        public Software()
        {
            
        }

        public string Tag { get; set; }
        public string FriendlyName { get; set; }
        public string Vendor { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }
        public bool X64Only { get; set; }
        public bool Automated { get; set; }
        public bool Licensed { get; set; }

        public string[] Steps { get; set; }
        public string[] Depends { get; set; }
    }
}
