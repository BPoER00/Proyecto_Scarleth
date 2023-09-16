"use client"
import { useVacunacion } from "@/context/Vacunacion.Context.js";

//components
import Steps from "./Steps";
import VacunacionList from "./VacunacionList";
import VacunacionNew from "./VacunacionNew";

function VacunacionActions() {
  const { paginate } = useVacunacion();

  return (
    <>
      <Steps />
      {paginate.map((page) => {
        if (page.id === 1 && page.status === "this") {
          return <VacunacionList key={page.id} />;
        } else if (page.id === 2 && page.status === "this") {
          return <VacunacionNew key={page.id} />;
        } else {
          return null;
        }
      })}
    </>
  );
}

export default VacunacionActions;