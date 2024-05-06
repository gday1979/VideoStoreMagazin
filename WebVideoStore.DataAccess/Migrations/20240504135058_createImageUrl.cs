using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebVideoStore.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class createImageUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "VideoTapes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://media.gettyimages.com/id/607392480/photo/actor-arnold-schwarzenegger-on-the-set-of-terminator.jpg?s=612x612&w=0&k=20&c=xAZepXUCji30y-KX2gsAzfGLsYjz58KYsngagBDiHZA=");

            migrationBuilder.UpdateData(
                table: "VideoTapes",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://media.gettyimages.com/id/583900608/photo/keanu-reeves-and-hugo-weaving-face-each-other-in-a-scene-from-andy-and-larry-wachowskis-1999.jpg?s=612x612&w=0&k=20&c=sJib2GLxgb1bxuZKq153zP7gtBaCoNU6nyYHnD7zK4k=");

            migrationBuilder.UpdateData(
                table: "VideoTapes",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://media.gettyimages.com/id/156477400/photo/al-pacino-marlon-brando-james-caan-and-john-cazale-publicity-portrait-for-the-film-the.jpg?s=612x612&w=0&k=20&c=zV3A2jNtTQ5fPLFnUCiAgIDP7PjAEg_7qe42u3M0mA0=");

            migrationBuilder.UpdateData(
                table: "VideoTapes",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://media.gettyimages.com/id/81975737/photo/chicago-ruben-chavez-of-chicago-nathan-robbel-of-chicago-and-odin-cabal-of-kenosha-pose-during.jpg?s=612x612&w=0&k=20&c=LT63FVSH51esYfYK_-2y1mulA-Q4SlHfm-v_BQ6hYd0=");

            migrationBuilder.UpdateData(
                table: "VideoTapes",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://media.gettyimages.com/id/159836292/photo/tim-robbins-in-a-scene-from-the-film-the-shawshank-redemption-1994.jpg?s=612x612&w=0&k=20&c=Dh6mgkr6sHke1wNtXIATUhHJ9CmzkEBRP5kHtYK5qpI=");

            migrationBuilder.UpdateData(
                table: "VideoTapes",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://media.gettyimages.com/id/2147912066/photo/john-travolta-at-the-2024-tcm-classic-film-festival-opening-night-screening-of-pulp-fiction.jpg?s=612x612&w=0&k=20&c=L0p6p3MUqnjAObX1Ln0CBakxlV0v1800q2toryimjPs=");

            migrationBuilder.UpdateData(
                table: "VideoTapes",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "https://media.gettyimages.com/id/1347822405/photo/hollywood-california-a-hannibal-lecter-jail-cell-from-silence-of-the-lambs-is-on-display-as.jpg?s=612x612&w=0&k=20&c=1zHh1lJmKj745H_cNTUHibfnKr6ft-26TGBDZ7VyB80=");

            migrationBuilder.UpdateData(
                table: "VideoTapes",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "https://media.gettyimages.com/id/162734047/photo/jack-nicholson-peering-through-axed-in-door-in-lobby-card-for-the-film-the-shining-1980.jpg?s=612x612&w=0&k=20&c=JKmcBH7ifAC2_6ZRe2mIZTLXChjqQpzUsECNl5-Sz8I=");

            migrationBuilder.UpdateData(
                table: "VideoTapes",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "https://media.gettyimages.com/id/607435710/photo/swedish-actor-max-von-sydow-and-american-actress-linda-blair-on-the-set-of-the-exorcist-based.jpg?s=612x612&w=0&k=20&c=xsv0DqutLgibuuBSTlohuFsDPKICnaK-9a2sZaZt2R8=");

            migrationBuilder.UpdateData(
                table: "VideoTapes",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "https://media.gettyimages.com/id/51039710/photo/cole-plays-a-boy-posssesed-by-supernatural-visions-and-paranormal-powers-8-year-old-haley-joel.jpg?s=612x612&w=0&k=20&c=Tzw6U63nNDuxF3Ooa7zzTrDkkd-PXLWYuEuucB96xeQ=");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "VideoTapes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "VideoTapes",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "VideoTapes",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "VideoTapes",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "VideoTapes",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "VideoTapes",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "VideoTapes",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "VideoTapes",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "VideoTapes",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "VideoTapes",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "");
        }
    }
}
