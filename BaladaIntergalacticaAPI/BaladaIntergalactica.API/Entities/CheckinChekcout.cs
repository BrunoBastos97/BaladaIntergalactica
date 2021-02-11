using System;

namespace BaladaIntergalactica.API.Entities
{
    public class CheckInCheckOut
    {
        public int Id { get; set; }
        public int IdAlien { get; set; }
        public int IdBallad { get; set; }
        public int? IdObjectNotAllowed { get; set; }
        public DateTime DateTimeEntry { get; set; }
        public DateTime? DateTimeExit { get; set; }
        public Alien Alien { get; set; }
        public Ballad Ballad { get; set; }
        public ObjectNotAllowed ObjectNotAllowed { get; set; }

        public CheckInCheckOut(int id, int idAlien, int idBallad, int? idObjectNotAllowed)
        {
            Id = id;
            IdAlien = idAlien;
            IdBallad = idBallad;
            IdObjectNotAllowed = idObjectNotAllowed;
        }
        
        public bool HasObjectNotAllowed()
        {
            return IdObjectNotAllowed != null;
        }

        public bool MinimumCheckOutTime(DateTime dateCheckOut)
        {
            var tempo = dateCheckOut - DateTimeEntry;

            return (tempo.TotalMinutes >= 1);
        }


        public void CheckIn()
        {
         
            if (HasObjectNotAllowed())
            {
                throw new Exception("Objeto proibido encontrado, Chekin não permitido");
            }

            DateTimeEntry = DateTime.Now;
        }

        public void CheckOut()
        {
            var now = DateTime.Now;

            if (!MinimumCheckOutTime(now))
            {
                throw new Exception("Tempo minimo para checkout, abaixo do permitido");
            }

            DateTimeExit = now;
        }

    }


}
