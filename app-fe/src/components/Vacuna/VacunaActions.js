"use client"
import { useVacuna } from "@/context/Vacuna.Context.js";

//components
import Steps from "./Steps";
import VacunaList from "./VacunaList";
import VacunaNew from "./VacunaNew";

function VacunaActions() {
  const { paginate } = useVacuna();

  return (
    <>
      <Steps />
      {paginate.map((page) => {
        if (page.id === 1 && page.status === "this") {
          return <VacunaList key={page.id} />;
        } else if (page.id === 2 && page.status === "this") {
          return <VacunaNew key={page.id} />;
        } else {
          return null;
        }
      })}
    </>
  );
}

export default VacunaActions;