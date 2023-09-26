import ReportesProvider from "@/context/Reportes.Context";
import Default from "@/components/Globales/Default";

function page() {
  return (
    <ReportesProvider>
      <Default>page</Default>
    </ReportesProvider>
  );
}

export default page;
