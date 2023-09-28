import React from "react";
import InputText from "../Inputs/InputText";
import InputSelect from "../Inputs/InputSelect";
import { useForm } from "react-hook-form";

function Filtros() {
  const {
    register,
    handleSubmit,
    formState: { errors },
    control,
  } = useForm();

  const asignacion = [];

  return (
    <div className="px-8 pt-6 pb-4 mb-1 dark:bg-gray-800 rounded">
      <div className="flex flex-wrap -mx-4">
        <div className="w-11/12 px-4 mb-4">
          <InputSelect
            label={"Nombre Vacuna"}
            name={"asignacion_id"}
            options={asignacion}
            control={control}
            placeholder={"Persona..."}
            errors={errors.asignacion_id?.message}
          />
        </div>
      </div>
    </div>
  );
}

export default Filtros;
