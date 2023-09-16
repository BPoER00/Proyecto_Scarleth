"use client"
import { useCargo } from "@/context/Cargo.Context.js";

//components
import Steps from "./Steps";
import CargoList from "./CargoList";
import CargoNew from "./CargoNew";

function CargoActions() {
  const { paginate } = useCargo();

  return (
    <>
      <Steps />
      {paginate.map((page) => {
        if (page.id === 1 && page.status === "this") {
          return <CargoList key={page.id} />;
        } else if (page.id === 2 && page.status === "this") {
          return <CargoNew key={page.id} />;
        } else {
          return null;
        }
      })}
    </>
  );
}

export default CargoActions;