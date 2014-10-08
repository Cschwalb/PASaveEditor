﻿using System.Collections.Generic;
using PASaveEditor;

namespace FileModel {
    internal class VictoryLog : Node {
        public readonly List<VictoryLogEntry> Log = new List<VictoryLogEntry>();


        public VictoryLog(string label)
            : base(label, true) {}


        public override Node CreateNode(string label) {
            if (Parser.IsId(label)) {
                var entry = new VictoryLogEntry(label);
                Log.Add(entry);
                return entry;
            } else {
                return base.CreateNode(label);
            }
        }


        public override void WriteProperties(Writer writer) {
            writer.WriteProperty("Size", Log.Count);
        }


        public override void WriteNodes(Writer writer) {
            foreach (VictoryLogEntry entry in Log) {
                writer.WriteNode(entry);
            }
        }
    }
}