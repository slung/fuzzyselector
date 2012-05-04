//using System;

//namespace UddiConnector.Ontology
//{

//    /// <summary>
//    ///   Clasă ce abstractizează forma unei cereri. Imutabilă.
//    /// </summary>
//    public sealed class RequestShape {

//        /// <summary>
//        ///   Forma cererii - termen fuzzy.
//        /// </summary>
//        public readonly Term shape;

//        /// <summary>
//        ///   Importanţa acestei forme (mai mare înseamnă mai important).
//        /// </summary>
//        public readonly int importance;

//        /// <param name="shape">Forma cererii - termen fuzzy</param>
//        /// <param name="importance">Importanţa acestei forme</param>
//        public RequestShape(Term shape, int importance) {

//            this.shape = shape.clone();
//            this.importance = importance;
//        }

//        /// <param name="serialized">Un obiect RequestShape serializat</param>
//        public RequestShape(string serialized) {
            
//            string[] aux = serialized.Split(new char[] { '\n' }, 6, StringSplitOptions.None);
            
//            this.shape = new Term(aux[0], aux[1], aux[2], aux[3], aux[4]);
            
//            int.TryParse(aux[5], out this.importance);
//        }

//        /// <summary>
//        ///   Serializează obiectul RequestShape pentru a putea fi trimis prin socket-uri.
//        /// </summary>
//        /// <returns>Obiectul serializat sub formă de string</returns>
//        public string serialize() {
            
//            return this.shape.name + "\n" + this.shape.start + "\n" + this.shape.left + "\n" + this.shape.right + "\n" + this.shape.end + "\n" + this.importance;
//        }
//    }
//}