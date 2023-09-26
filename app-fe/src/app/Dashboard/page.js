import DashboardProvider from "@/context/Dashboard.Context";
import Default from "@/components/Globales/Default";

function page() {
  return (
    <DashboardProvider>
      <Default>page</Default>
    </DashboardProvider>
  );
}

export default page;
