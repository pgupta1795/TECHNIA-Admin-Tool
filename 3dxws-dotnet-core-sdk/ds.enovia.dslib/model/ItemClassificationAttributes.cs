﻿//------------------------------------------------------------------------------------------------------------------------------------
// Copyright 2020 Dassault Systèmes - CPE EMED
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify,
// merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished
// to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES 
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS
// BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//------------------------------------------------------------------------------------------------------------------------------------

using ds.enovia.common.collection;
using System.Collections.Generic;

namespace ds.enovia.dslib.model
{
    public class ItemClassificationAttributes
    {
        public string id { get; set; }

        public string name { get; set; }
        public string title { get; set; }

        public ItemSet<ClassAttributes> ClassificationAttributes { get; set; }

        public List<ClassAttribute> AsList() {

            List<ClassAttribute> lst = new List<ClassAttribute> ();

            foreach (ClassAttributes classAttributes in ClassificationAttributes.member)
            {
                foreach (ClassAttribute attribute in classAttributes.Attributes)
                {
                    lst.Add(attribute);
                }
            }

            return lst;
        }
    }
}
