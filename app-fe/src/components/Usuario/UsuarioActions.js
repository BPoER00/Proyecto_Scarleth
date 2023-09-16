"use client"
import { useUsuario } from "@/context/Usuario.Context";

//components
import Steps from "./Steps";
import UsuarioList from "./UsuarioList";
import UsuarioNew from "./UsuarioNew";

function UsuarioActions() {
  const { paginate } = useUsuario();

  return (
    <>
      <Steps />
      {paginate.map((page) => {
        if (page.id === 1 && page.status === "this") {
          return <UsuarioList key={page.id} />;
        } else if (page.id === 2 && page.status === "this") {
          return <UsuarioNew key={page.id} />;
        } else {
          return null;
        }
      })}
    </>
  );
}

export default UsuarioActions;