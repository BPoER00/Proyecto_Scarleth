import VacunaProvider from "@/context/Vacuna.Context";
import Default from "@/components/Globales/Default";
import VacunaActions from "@/components/Vacuna/VacunaActions";

function page() {
  return (
    <VacunaProvider>
      <Default><VacunaActions/></Default>
    </VacunaProvider>
  );
}

export default page;
