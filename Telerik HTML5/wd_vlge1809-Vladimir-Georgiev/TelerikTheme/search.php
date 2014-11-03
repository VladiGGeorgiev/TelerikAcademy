<?php get_header(); ?>
<div id="content">
	<div id="posts-wrap">
		<?php if (have_posts()) : ?>
			<h1 id="search-title" class="pagetitle">
				Search Results for: 
				<?php echo get_search_query(); ?>
			</h1>

			<?php while (have_posts()) : the_post(); ?>
				<div id="search-results">
					<?php
						if ( function_exists("has_post_thumbnail") && has_post_thumbnail() ) { 
						the_post_thumbnail(array(260,200), 
						array("class" => "alignleft post_thumbnail")); 
						} 
					?>
					<h2 class="title" id="post-<?php the_ID(); ?>">
						<a href="<?php the_permalink() ?>" rel="bookmark" title="Permanent Link to <?php the_title_attribute(); ?>">
							<?php the_title(); ?>
						</a>
					</h2>
					<div class="postdate">
						<?php the_date();?>
						<?php the_author();?>
						<?php 
							if (current_user_can('edit_post', $post->ID)) {
								edit_post_link('Edit', '', ''); 
							} 
						?>
					</div>
					<div class="entry">
						<?php the_excerpt() ?>
					</div>
				</div>
			<?php endwhile; ?>

			<div class="navigation">
				<?php if(function_exists('wp_pagenavi')) { wp_pagenavi(); } else { ?>
				<div class="alignleft"><?php next_posts_link('&laquo; Older Entries') ?></div>
				<div class="alignright"><?php previous_posts_link('Newer Entries &raquo;') ?></div>
				<?php } ?>
			</div>

		<?php else : ?>
			<h2 class="pagetitle">No posts found. Try a different search?</h2>
			<?php get_search_form(); ?>
		<?php endif; ?>
	</div>
</div>
<?php get_sidebar(); ?>
<?php get_footer(); ?>