import DashboardProvider from "@/context/Dashboard.Context";
import Default from "@/components/Globales/Default";
import InfoDashboard from "@/components/Dashboard/InfoDashboard";

function page() {
  return (
    <DashboardProvider>
      <Default>
        <InfoDashboard />
      </Default>
    </DashboardProvider>
  );
}

export default page;
