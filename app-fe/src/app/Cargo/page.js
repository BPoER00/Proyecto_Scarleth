import CargoProvider from "@/context/Cargo.Context";
import Default from "@/components/Globales/Default";
import CargoActions from "@/components/Cargo/CargoActions";


function page() {
  return (
    <CargoProvider>
      <Default><CargoActions/></Default>
    </CargoProvider>
  );
}

export default page;
