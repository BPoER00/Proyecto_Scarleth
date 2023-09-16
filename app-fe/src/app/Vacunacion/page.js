import VacunacionProvider from "@/context/Vacunacion.Context";
import Default from "@/components/Globales/Default";
import VacunacionActions from "@/components/Vacunación/VacunacionActions";

function page() {
  return (
    <VacunacionProvider>
      <Default><VacunacionActions/></Default>
    </VacunacionProvider>
  );
}

export default page;
