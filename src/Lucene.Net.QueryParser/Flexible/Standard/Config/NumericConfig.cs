﻿using Lucene.Net.Support;
using System;
using Lucene.Net.Documents;

namespace Lucene.Net.QueryParsers.Flexible.Standard.Config
{
    /*
     * Licensed to the Apache Software Foundation (ASF) under one or more
     * contributor license agreements.  See the NOTICE file distributed with
     * this work for additional information regarding copyright ownership.
     * The ASF licenses this file to You under the Apache License, Version 2.0
     * (the "License"); you may not use this file except in compliance with
     * the License.  You may obtain a copy of the License at
     *
     *     http://www.apache.org/licenses/LICENSE-2.0
     *
     * Unless required by applicable law or agreed to in writing, software
     * distributed under the License is distributed on an "AS IS" BASIS,
     * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
     * See the License for the specific language governing permissions and
     * limitations under the License.
     */

    /// <summary>
    /// This class holds the configuration used to parse numeric queries and create
    /// <see cref="Search.NumericRangeQuery"/>s.
    /// </summary>
    /// <seealso cref="Search.NumericRangeQuery"/>
    /// <seealso cref="Support.NumberFormat"/>
    public class NumericConfig
    {
        private int precisionStep;

        private NumberFormat format;

        private NumericType type;

        /// <summary>
        /// Constructs a <see cref="NumericConfig"/> object.
        /// </summary>
        /// <param name="precisionStep">the precision used to index the numeric values</param>
        /// <param name="format">the <see cref="NumberFormat"/> used to parse a <see cref="string"/> to an <see cref="object"/> representing a .NET numeric type.</param>
        /// <param name="type">the numeric type used to index the numeric values</param>
        /// <seealso cref="NumericConfig.PrecisionStep"/>
        /// <seealso cref="NumericConfig.NumberFormat"/>
        /// <seealso cref="Type"/>
        public NumericConfig(int precisionStep, NumberFormat format,
            NumericType type)
        {
            PrecisionStep = precisionStep;
            NumberFormat = format;
            Type = type;
        }

        /// <summary>
        /// Gets or sets the precision used to index the numeric values
        /// </summary>
        /// <seealso cref="Search.NumericRangeQuery{T}.PrecisionStep"/>
        public virtual int PrecisionStep
        {
            get { return precisionStep; }
            set { precisionStep = value; }
        }

        /// <summary>
        /// Gets or Sets the <seealso cref="Support.NumberFormat"/> used to parse a <see cref="string"/> to
        /// <see cref="object"/> representing a .NET numeric type, cannot be <c>null</c>
        /// </summary>
        public virtual NumberFormat NumberFormat
        {
            get { return format; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("format cannot be null!");
                }

                this.format = value;
            }
        }

        /// <summary>
        /// Gets or Sets the numeric type used to index the numeric values
        /// </summary>
        public virtual NumericType Type
        {
            get { return type; }
            set { type = value; }
        }

        public override bool Equals(object obj)
        {
            if (obj == this) return true;

            if (obj is NumericConfig)
            {
                NumericConfig other = (NumericConfig)obj;

                if (this.precisionStep == other.precisionStep
                    && this.type == other.type
                    && (this.format == other.format || (this.format.Equals(other.format))))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// LUCENENET specific - Visual Studio provides a compiler warning if
        /// <see cref="Equals(object)"/> is overridden without <see cref="GetHashCode()"/>,
        /// so we provide an implementation that mirrors <see cref="Equals(object)"/>.
        /// </summary>
        public override int GetHashCode()
        {
            return HashHelpers.CombineHashCodes(
                base.GetHashCode(), 
                this.precisionStep.GetHashCode(), 
                this.type.GetHashCode(), 
                this.format.GetHashCode());
        }
    }
}
