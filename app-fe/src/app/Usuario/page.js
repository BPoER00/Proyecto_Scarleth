import UsuarioProvider from "@/context/Usuario.Context";
import Default from "@/components/Globales/Default";

function page() {
  return (
    <UsuarioProvider>
      <Default>page</Default>
    </UsuarioProvider>
  );
}

export default page;
