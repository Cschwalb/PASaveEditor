using System;

namespace PASaveEditor.FileModel
{
    internal class GangMember : Node
    {
        public int PrisonerId;
        public int GangID;
        public string GangRank;
        public double GangRecruitment;


        public GangMember(string label)
            : base(label) { }


        public override void ReadKey(string key, string value)
        {
            switch (key)
            {
                case "Prisoner.i":
                    PrisonerId = Int32.Parse(value);
                    break;
                case "Gang.Id":
                    GangID = Int32.Parse(value);
                    break;
                case "Gang.Rank":
                    GangRank = value;
                    break;
                case "Gang.Recruitment":
                    GangRecruitment = Double.Parse(value);
                    break;
                default:
                    base.ReadKey(key, value);
                    break;
            }
        }


        public override void WriteProperties(Writer writer)
        {
            writer.WriteProperty("Prisoner.i", PrisonerId);
            writer.WriteProperty("Gang.Id", GangID);
            writer.WriteProperty("Gang.Rank", GangRank);
            writer.WriteProperty("Gang.Recruitment", GangRecruitment);
        }
    }
}
