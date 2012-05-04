using System;
using System.Collections.Generic;

namespace UddiConnector.Ontology
{

    public enum CompositionMethod 
    {
        STATISTICAL,
        CUMULATIVE,
        AVERAGE
    };

    public class OntologyProperty {

        public readonly string name;
        public readonly CompositionMethod compositionMethod;

        public OntologyProperty(string name, CompositionMethod compositionMethod)
        {

            this.name = name;
            this.compositionMethod = compositionMethod;
        }

        public static CompositionMethod GetCompositionMethodFromString(string compositionMethodString)
        {
            switch (compositionMethodString.ToLowerInvariant())
            {
                case "statistical":
                {
                    return CompositionMethod.STATISTICAL;
                }
                case "cumulative":
                {
                    return CompositionMethod.CUMULATIVE;
                }
                case "average":
                {
                    return CompositionMethod.AVERAGE;
                }
                default:
                {
                    return CompositionMethod.CUMULATIVE;
                }
            }
        }

        public override string ToString()
        {
            return this.name;
        } 
    }
}
