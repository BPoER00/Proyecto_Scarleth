import { get } from "@/api/Vacuna.Api.js";

function page() {
  const direccion = async () => {
    console.log(await get());
  };

  direccion();
  return <div>page</div>;
}

export default page;
