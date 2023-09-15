import PersonaProvider from "@/context/Persona.Context";
import Default from "@/components/Globales/Default";

function page() {
  return (
    <PersonaProvider>
      <Default>page</Default>
    </PersonaProvider>
  );
}

export default page;
