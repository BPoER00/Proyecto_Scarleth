"use client"
import { usePersona } from "@/context/Persona.Context.js";

//components
import Steps from "./Steps";
import PersonaList from "./PersonaList";
import PersonaNew from "./PersonaNew";

function PersonaActions() {
  const { paginate } = usePersona();

  return (
    <>
      <Steps />
      {paginate.map((page) => {
        if (page.id === 1 && page.status === "this") {
          return <PersonaList key={page.id} />;
        } else if (page.id === 2 && page.status === "this") {
          return <PersonaNew key={page.id} />;
        } else {
          return null;
        }
      })}
    </>
  );
}

export default PersonaActions;