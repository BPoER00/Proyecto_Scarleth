import VacunaProvider from "@/context/Vacuna.Context";
import Default from "@/components/Globales/Default";

function page() {
  return (
    <VacunaProvider>
      <Default>page</Default>
    </VacunaProvider>
  );
}

export default page;
