import CargoProvider from "@/context/Cargo.Context";
import Default from "@/components/Globales/Default";

function page() {
  return (
    <CargoProvider>
      <Default>page</Default>
    </CargoProvider>
  );
}

export default page;
