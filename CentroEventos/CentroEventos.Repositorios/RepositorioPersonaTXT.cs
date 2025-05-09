namespace CentroEventos.Repositorios;
using CentroEventos.Aplicacion.Persona;
    public class RepositorioPersonaTXT : IRepositorioPersona
    {
        readonly string _nombreArch = "personas.txt";
        public void AgregarPersona(Persona persona){
            using var sw = new StreamWriter(_nombreArch, true);
            
            sw.WriteLine(persona.Id);
            sw.WriteLine(persona.Dni);
            sw.WriteLine(persona.Nombre);
            sw.WriteLine(persona.Apellido);
            sw.WriteLine(persona.Email);
            sw.WriteLine(persona.Telefono);
        }
        public List<Persona> ListarPersonas(){
            var resultado = new List<Persona>();
            using var sr = new StreamReader(_nombreArch);

            while (!sr.EndOfStream)
            {
                
                int personaId = int.Parse(sr.ReadLine() ?? "");
                string personaDni = sr.ReadLine() ?? "";
                string personaNombre = sr.ReadLine() ?? "";
                string personaApellido = sr.ReadLine() ?? "";
                string personaEmail = sr.ReadLine() ?? "";
                string personaTelefono = sr.ReadLine() ?? "";
                var persona = new Persona(personaId,personaDni,personaNombre,personaApellido,personaEmail,personaTelefono);
                resultado.Add(persona);
            }
            return resultado;
        }

        public void EliminarPersona(int id){
            using var sw = new StreamWriter(_nombreArch, true);

            
        }

        public void ModificarPersona(int id){
            using var sr = new StreamReader(_nombreArch);
            bool encontre = false; 
            while (!sr.EndOfStream && !encontre)
            {
                int personaId = int.Parse(sr.ReadLine() ?? "");
                if(personaId == id)
                    encontre = true;
                else{
                    for (int i= 0; i<5;i++){
                        string aux = sr.ReadLine() ?? "";
                    }    
                }
            }
            if(encontre){
                string personaDni;
                string personaNombre;
                string personaApellido;
                string personaEmail;
                string personaTelefono;
                AgregarPersona(PedirDatosPersona(id));
            }    
        }

        public Persona PedirDatosPersona(int id){

            string personaDni;
            string personaNombre;
            string personaApellido;
            string personaEmail;
            string personaTelefono;
            Persona per = new Persona(id,);
            
        }
}