using System.Collections.Generic;

namespace PASaveEditor.FileModel
{
    internal class Gang : Node
    {
        public readonly List<GangMember> Prisoners = new List<GangMember>();


        public Gang(string label)
            : base(label, true) { }


        public override void ReadKey(string key, string value)
        {
            if (!"Size".Equals(key))
            {
                // do not store size -- it will be counted and written at save-time
                base.ReadKey(key, value);
            }
        }


        public override Node CreateNode(string label)
        {
            if (Parser.IsId(label))
            {
                var member = new GangMember(label);
                Prisoners.Add(member);
                return member;
            }
            else
            {
                return base.CreateNode(label);
            }
        }


        public override void WriteProperties(Writer writer)
        {
            writer.WriteProperty("Size", Prisoners.Count);
        }


        public override void WriteNodes(Writer writer)
        {
            for (int i = 0; i < Prisoners.Count; i++)
            {
                GangMember member = Prisoners[i];
                member.Label = "[G " + i + "]"; // used to be i
                writer.WriteNode(member);
            }
        }
    }
}
