﻿using System.Collections.Generic;

namespace WForRestGet.DataModel
{
    public class Answer
    {
        public int Id { get; set; }
        public string AnswerType { get; set; }
        public string AnswerDescription { get; set; }
        public List<Datauser> Datausers { get; set; }
    }
}
