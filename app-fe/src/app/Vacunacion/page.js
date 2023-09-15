import VacunacionProvider from "@/context/Vacunacion.Context";
import Default from "@/components/Globales/Default";

function page() {
  return (
    <VacunacionProvider>
      <Default>page</Default>
    </VacunacionProvider>
  );
}

export default page;
