import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import { ValidateDetalleVacunacion } from "@/validations/DetalleVacunacion.Validation";
import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import InputText from "../Inputs/InputText";
import { useVacunacion } from "@/context/Vacunacion.Context";
import InputSelect from "../Inputs/InputSelect";

function ActionModal({ id, action }) {
  const { asignacion, insertDetalleVacunacion } = useVacunacion();

  const sleep = (ms) => {
    return new Promise((resolve) => setTimeout(resolve, ms));
  };

  const {
    register,
    handleSubmit,
    formState: { errors },
    control,
  } = useForm({
    resolver: yupResolver(ValidateDetalleVacunacion),
  });

  const onSubmit = async (e) => {
    var detalleVacuna = {
      vacunacion_id: id,
      fecha_vacunacion: e.fecha_vacunacion,
      dosis: e.dosis,
      asignacion_id: e.asignacion_id,
    };

    const res = await insertDetalleVacunacion(detalleVacuna);

    if (res.data === true) {
      toast.success("Vacunacion Realizada Correctamente");
      await sleep(3000);
      action();
    } else if (res.status === 400 || res.status === 401) {
      toast.warning(`Error ${res.data.message}`);
    }
  };

  return (
    <>
      <ToastContainer />
      <form
        onSubmit={handleSubmit(onSubmit)}
        className="px-8 pt-6 pb-8 mb-4 dark:bg-gray-900 rounded"
      >
        <div className="mb-4">
          <InputSelect
            label={"Asignacion"}
            name={"asignacion_id"}
            options={asignacion}
            control={control}
            placeholder={"Ingrese Asignacion..."}
            errors={errors.asignacion_id?.message}
          />
        </div>

        <div className="mb-4">
          <InputText
            label={"Fecha Vacunacion"}
            name={"fecha_vacunacion"}
            type={"date"}
            placeholder={"Ingrese Fecha Vacunacion..."}
            register={register}
            errors={errors.fecha_vacunacion?.message}
          />
        </div>

        <div className="mb-4">
          <InputText
            label={"Dosis"}
            name={"dosis"}
            type={"number"}
            placeholder={"Ingrese Dosis..."}
            register={register}
            errors={errors.dosis?.message}
          />
        </div>

        <div className="mb-6 text-center">
          <button
            className="w-full mt-3 px-4 py-2 font-bold text-white bg-blue-500 rounded-full hover:bg-blue-700 focus:outline-none focus:shadow-outline"
            type="submit"
          >
            Registrar Revision
          </button>
        </div>
        <hr className="mb-6 border-t" />
      </form>
    </>
  );
}

export default ActionModal;
