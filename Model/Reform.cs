﻿using System.Collections.Generic;

namespace PASaveEditor.Model {
    class Reform : Node {
        public List<ReformProgram> Programs;


        public Reform(string label)
            : base(label) {}
    }
}
