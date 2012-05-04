using System.Net;

namespace FuzzySelector.Common.Communication {

    /// <summary>
    ///   Interfaţa pentru servicii care ascultă şi răspund la mesaje.
    /// </summary>
    public interface ITransformer {

        /// <summary>
        ///   Metodă generală care transformă un mesaj cerere într-un mesaj răspuns.
        /// </summary>
        /// <param name="message">Mesajul ce conţine cererea</param>
        /// <param name="from">Adresa IP a sursei</param>
        /// <returns>Mesaj care conţine răspunsul la cerere</returns>
        Message answer(Message message, IPAddress from);
    }
}
