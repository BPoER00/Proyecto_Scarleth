import UsuarioProvider from "@/context/Usuario.Context";
import Default from "@/components/Globales/Default";
import UsuarioActions from "@/components/Usuario/UsuarioActions";

function page() {
  return (
    <UsuarioProvider>
      <Default><UsuarioActions/></Default>
    </UsuarioProvider>
  );
}

export default page;
