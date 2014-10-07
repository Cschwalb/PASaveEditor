﻿using System.Collections.Generic;

namespace PASaveEditor.Model {
    class Objects : Node {
        public readonly Dictionary<int, ObjectBase> OtherObjects = new Dictionary<int, ObjectBase>();
        public readonly Dictionary<int, Prisoner> Prisoners = new Dictionary<int, Prisoner>();


        public Objects(string label)
            : base(label) {}


        public override void ReadKey(string key, string value) {
            if (!"Size".Equals(key)) {
                base.ReadKey(key, value);
            }
        }


        public override Node CreateNode(string label) {
            ObjectBase newObj = new ObjectBase(label);
            OtherObjects.Add(newObj.Id,newObj);
            return newObj;
        }


        public override void FinishedReadingNode(Node node) {
            ObjectBase obj = (ObjectBase)node;
            if ("Prisoner".Equals(obj.Type) ) {
                OtherObjects.Remove(obj.Id);
                Prisoner prisoner = new Prisoner(obj);
                Prisoners.Add(prisoner.Id,prisoner);
            }
        }
    }
}
