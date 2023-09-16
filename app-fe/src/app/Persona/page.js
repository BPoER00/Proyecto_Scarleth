import PersonaProvider from "@/context/Persona.Context";
import Default from "@/components/Globales/Default";
import PersonaActions from "@/components/Persona/PersonaActions";

function page() {
  return (
    <PersonaProvider>
      <Default><PersonaActions/></Default>
    </PersonaProvider>
  );
}

export default page;
